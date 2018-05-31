using System;
using System.Drawing;
using System.Windows.Forms;
using B18Ex05.Checkers.Model;
using B18Ex05.Checkers.View;

namespace B18Ex05.Checkers.Controller
{
	public delegate void GameOver(string i_PlayerName);

	public class GameController
	{
		private readonly GameWindow r_View = new GameWindow();
		private readonly Game r_Model = new Game();
		private bool m_IsFirstMove = true;

		public event GameOver GameIsOver;

		public GameController()
		{
			if (r_View.DialogResult != DialogResult.Cancel)
			{
				initializeGame();
				r_View.ShowDialog();
			}
		}

		private void playCurrentTurn(Point i_Location, Point i_Destination)
		{
			tryExecutePlayerAction(i_Location, i_Destination);

			checkForContinuousEatingMoves();

			checkIfComputerAndPlayItsTurn();
		}

		private void tryExecutePlayerAction(Point i_Location, Point i_Destination)
		{
			if (m_IsFirstMove)
			{
				r_Model.FindPlayersFirstMoves(r_Model.CurrentPlayerTurn);
			}

			if (!validateAndExecuteSelectedMove(i_Location, i_Destination, out bool isEatingMove))
			{
				if (isEatingMove)
				{
					throw new ArgumentException(string.Format("Illegal action! {0}Must preform an eating move!", Environment.NewLine));
				}

				throw new ArgumentException(string.Format("Illegal action! {0}Must move to an adjacent empty space!", Environment.NewLine));
			}
		}

		private void checkIfComputerAndPlayItsTurn()
		{
			if (r_Model.IsCurrentPlayerComputer())
			{
				doComputerTurn();
				onEndTurnActions();
			}
		}

		private void checkForContinuousEatingMoves()
		{
			if (r_Model.WasPieceEaten)
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
		}

		private bool validateAndExecuteSelectedMove(Point i_Location, Point i_Destination, out bool o_IsEatingMove)
		{
			bool isLegalMove = false;
			o_IsEatingMove = false;

			foreach (PieceMove pieceMove in r_Model.CurrentMoves)
			{
				if (pieceMove.Location == i_Location && pieceMove.Destination == i_Destination)
				{
					r_Model.MakePlayerMove(r_Model.CurrentMoves.IndexOf(pieceMove));
					isLegalMove = true;
					m_IsFirstMove = false;
					break;
				}

				o_IsEatingMove = o_IsEatingMove || pieceMove.DoesEat;
			}

			return isLegalMove;
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
			initializeEvents();
			initializePlayerOne();
			initializePlayerTwo(!r_View.IsPlayerTwoActive);
			initializeBoard(r_View.GameWindowSize);
		}

		private void initializeEvents()
		{
			//Initialize Model Events
			r_Model.ChangeScore += r_View.OnScoreChanged;
			r_Model.MakeKing += r_View.OnGameButtonChangeSymbol;
			r_Model.PieceRemoved += r_View.OnGameButtonRemoved;
			r_Model.PieceMoved += r_View.OnGameButtonMove;
			r_Model.ComputerPieceMoved += r_View.onComputerGamePieceMove;
			//Initialize View Events
			r_View.ResetGame += resetGameData;
			r_View.UserMoveSelect += playCurrentTurn;
			r_View.WindowButtonSelect += r_Model.ValidatePieceSelection;
			//Initialize Controller Events
			GameIsOver += r_View.OnGameOver;
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
			r_Model.AddListnerToGamePieceCreated(r_View.OnGameButtonCreated);
			r_Model.InitializeBoard();
		}
	}
}