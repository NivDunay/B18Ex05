using System;
using System.Drawing;
using B18Ex05.Checkers.Model;
using B18Ex05.Checkers.View;

namespace B18Ex05.Checkers.Controller
{
	public delegate void IllegalMove();

	public delegate void GameOver(string i_PlayerName);

	public class GameController
	{
		private readonly GameBoard r_View = new GameBoard();
		private readonly Game r_Model = new Game();
		private bool m_IsFirstMove = true;

		public event IllegalMove IllegalMoveMade;

		public event GameOver GameIsOver;

		public GameController()
		{
			initializeGame();
			r_View.ShowDialog();
		}

		private void playCurrentTurn(Point i_Location, Point i_Destination)
		{
			bool isLegalMove = false;
			if (m_IsFirstMove)
			{
				r_Model.FindPlayersFirstMoves(r_Model.CurrentPlayerTurn);
			}

			foreach (PieceMove pieceMove in r_Model.CurrentMoves)
			{
				if (pieceMove.Location == i_Location && pieceMove.Destination == i_Destination)
				{
					r_Model.MakePlayerMove(r_Model.CurrentMoves.IndexOf(pieceMove));
					isLegalMove = true;
					m_IsFirstMove = false;
					break;
				}
			}

			if (!isLegalMove)
			{
				IllegalMoveMade?.Invoke();
			}
			else if (r_Model.WasPieceEaten)
			{
				if (!r_Model.FindPlayersContinuationMoves())
				{
					onEndTurnActions();
				}
			}
			else
			{
				onEndTurnActions();
			}

			if (r_Model.IsCurrentPlayerComputer())
			{
				doComputerTurn();
				onEndTurnActions();
			}
		}

		private void doComputerTurn()
		{
			Random selectedMove = new Random();
			r_Model.FindPlayersFirstMoves(r_Model.CurrentPlayerTurn);
			int randomGeneratedMove = selectedMove.Next(0, r_Model.CurrentMoves.Count - 1);
			r_Model.MakePlayerMove(randomGeneratedMove);
			if (r_Model.CurrentMoves[randomGeneratedMove].DoesEat)
			{
				while (r_Model.FindPlayersContinuationMoves())
				{
					randomGeneratedMove = selectedMove.Next(0, r_Model.CurrentMoves.Count - 1);
					r_Model.MakePlayerMove(randomGeneratedMove);
				}
			}
		}

		private void onEndTurnActions()
		{
			r_Model.EndTurn();
			m_IsFirstMove = true;
			if (!r_Model.FindPlayersFirstMoves(r_Model.CurrentPlayerTurn))
			{
				string winnerName = checkWhoTheWinnerIs();
				if (winnerName != null)
				{
					uint winnerScore = r_Model.CalculatePlayerScore(r_Model.OtherPlayer()) - r_Model.CalculatePlayerScore(r_Model.CurrentPlayerTurn);
					r_Model.SetPlayerScore(winnerScore, r_Model.OtherPlayer());
				}

				GameIsOver?.Invoke(r_Model.GetPlayerName(r_Model.OtherPlayer()));
				resetGameData();
			}
		}

		private string checkWhoTheWinnerIs()
		{
			string winner = !r_Model.FindPlayersFirstMoves(r_Model.OtherPlayer()) ? null : r_Model.GetPlayerName(r_Model.OtherPlayer());
			return winner;
		}

		private void resetGameData()
		{
			r_Model.ResetGameData();
		}

		private void initializeGame()
		{
			bool playerTwoActive = r_View.IsPlayerTwoActive;
			initializePlayerOne();
			initializePlayerTwo(!playerTwoActive);
			initializeBoard(r_View.GameBoardSize);
			r_View.UserMoveSelcted += playCurrentTurn;
			r_Model.MakeKing += r_View.OnGameButtonChangeSymbol;
			r_Model.PieceRemoved += r_View.OnGameButtonRemoved;
			r_Model.PieceMoved += r_View.OnGameButtonMove;
			IllegalMoveMade += r_View.OnIllegalMove;
			GameIsOver += r_View.OnGameOver;
			r_View.StartGame += resetGameData;
			r_Model.ChangeScore += r_View.OnScoreChanged;
		}

		private void initializePlayerOne()
		{
			r_Model.InitializePlayerOne(r_View.PlayerOneName);
		}

		private void initializePlayerTwo(bool i_PlayerTwoIsComputer)
		{
			r_Model.InitializePlayerTwo(r_View.PlayerTwoName, i_PlayerTwoIsComputer);
		}

		private void initializeBoard(int i_GameBoardSize)
		{
			r_Model.CreateGameBoard(i_GameBoardSize);
			r_Model.AddListnerToGamePieceCreated(r_View.NewGamePieceCreatedHandler);
			r_Model.InitializeBoard();
		}
	}
}