using System;
using B18Ex05.Checkers.Model;
using B18Ex05.Checkers.View;

namespace B18Ex05.Checkers.Controller
{
	public class GameController
	{
		private readonly GameBoard r_View             = new GameBoard();
		private readonly Game      r_Model            = new Game();
		private          bool      m_PlayAnotherRound = false;

		public GameController()
		{
			InitializeGame();
			r_View.ShowDialog();
		}
		/*
		public void IsAnotherRound()
		{
			m_PlayAnotherRound = r_View.AskForAnotherRound();
			if (m_PlayAnotherRound)
			{
				resetGameData();
			}
		}

		private void resetGameData()
		{
			r_Model.ResetGameData();
		}

		public bool PlayAnotherRound
		{
			get { return m_PlayAnotherRound; }
		}

		public void PlayCurrentTurn()
		{
			bool canPlayerQuit = canCurrentPlayerQuit();
			r_Model.IsGameOver = doesCurrentPlayerHaveMoves();
			if (!r_Model.IsGameOver)
			{
				r_View.TurnInformation(
					r_Model.GetPlayerName(r_Model.CurrentPlayerTurn),
					r_Model.GetPlayerSymbol(r_Model.CurrentPlayerTurn),
					r_Model.GetPlayerName(r_Model.OtherPlayer()),
					r_Model.GetPlayerSymbol(r_Model.OtherPlayer()));
				decideActionForCurrentTurn(canPlayerQuit, out int playerSelectedMove);
				if (!r_Model.DidPlayerQuit)
				{
					makePlayerMove(playerSelectedMove);
					while (r_Model.WasPieceEaten && r_Model.FindPlayersContinuationMoves() && !r_Model.DidPlayerQuit)
					{
						r_View.TurnInformation(
							r_Model.GetPlayerName(r_Model.CurrentPlayerTurn),
							r_Model.GetPlayerSymbol(r_Model.CurrentPlayerTurn),
							r_Model.GetPlayerName(r_Model.CurrentPlayerTurn),
							r_Model.GetPlayerSymbol(r_Model.CurrentPlayerTurn));
						canPlayerQuit = canCurrentPlayerQuit();
						decideActionForCurrentTurn(canPlayerQuit, out playerSelectedMove);
						if (!r_Model.DidPlayerQuit)
						{
							makePlayerMove(playerSelectedMove);
						}
					}

					if (!r_Model.DidPlayerQuit)
					{
						r_Model.EndTurn();
					}
				}
			}

			r_Model.IsGameOver = r_Model.DidPlayerQuit || r_Model.IsGameOver;
		}

		private void makePlayerMove(int i_PlayerSelectedMove)
		{
			r_Model.MakePlayerMove(i_PlayerSelectedMove);
			r_Model.CheckAndMakeKing();
			PrintBoard();
		}

		private bool canCurrentPlayerQuit()
		{
			return ((int) r_Model.CalculatePlayerScore(r_Model.CurrentPlayerTurn) -
					(int) r_Model.CalculatePlayerScore(r_Model.OtherPlayer())) < 0;
		}

		private void decideActionForCurrentTurn(bool i_CanPlayerQuit, out int o_PlayerSelectedMove)
		{
			Random selectedAction = new Random();
			if (!r_Model.IsCurrentPlayerComputer())
			{
				r_Model.DidPlayerQuit = r_View.GetPlayerInput(r_Model.GetCurrentMoves(), i_CanPlayerQuit, out o_PlayerSelectedMove);
			}
			else
			{
				o_PlayerSelectedMove = selectedAction.Next(0, r_Model.GetCurrentMoves().Count - 1);
				r_View.LastAction    = r_Model.GetCurrentMoves()[o_PlayerSelectedMove];
			}
		}

		public bool IsGameOver()
		{
			return r_Model.IsGameOver;
		}

		private bool checkIfTie()
		{
			return !r_Model.DidPlayerQuit && !r_Model.FindPlayersFirstMoves(r_Model.OtherPlayer());
		}

		public void GameOver()
		{
			if (checkIfTie())
			{
				r_View.PrintTie();
			}
			else
			{
				uint winnerScore;
				winnerScore = r_Model.CalculatePlayerScore(r_Model.OtherPlayer()) -
							  r_Model.CalculatePlayerScore(r_Model.CurrentPlayerTurn);
				r_Model.SetPlayerScore(winnerScore, r_Model.OtherPlayer());
				r_View.PrintWinner(r_Model.GetPlayerName(r_Model.OtherPlayer()), r_Model.GetPlayerSymbol(r_Model.OtherPlayer()),
					winnerScore);
			}

			r_View.PrintGameOver(
				r_Model.GetPlayerName(r_Model.CurrentPlayerTurn),
				r_Model.GetPlayerScore(r_Model.CurrentPlayerTurn),
				r_Model.GetPlayerName(r_Model.OtherPlayer()),
				r_Model.GetPlayerScore(r_Model.OtherPlayer()));
		}

		private bool doesCurrentPlayerHaveMoves()
		{
			bool doesCurrentPlayerHaveMoves;
			doesCurrentPlayerHaveMoves = !doesCurrentPlayerHaveLegalMoves() || !doesCurrentPlayerHavePiecesLeft();
			return doesCurrentPlayerHaveMoves;
		}

		private bool doesCurrentPlayerHavePiecesLeft()
		{
			bool doesPiecesLeft = true;
			if (r_Model.GetPlayerNumberOfPieces(r_Model.CurrentPlayerTurn) == 0)
			{
				doesPiecesLeft = false;
			}

			return doesPiecesLeft;
		}

		private bool doesCurrentPlayerHaveLegalMoves()
		{
			bool doesPlayerHaveLegalMoves = true;
			if (!r_Model.FindPlayersFirstMoves(r_Model.CurrentPlayerTurn))
			{
				doesPlayerHaveLegalMoves = false;
			}

			return doesPlayerHaveLegalMoves;
		}
		*/
		public void InitializeGame()
		{
			bool playerTwoActive = r_View.IsPlayerTwoActive;
			initializePlayerOne();
			initializePlayerTwo(playerTwoActive);
			initializeBoard(r_View.GameBoardSize);
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
			r_Model.AddListnerToGamePieceCreated(r_View.newGamePieceCreatedHandler);
			r_Model.InitializeBoard();
		}
		/*
		private void initializeViewBoard()
		{
			r_View.GameBoard = new char[r_Model.BoardSize, r_Model.BoardSize];
			updateBoard();
		}
		
		private void updateBoard()
		{
			for (int row = 0; row < r_View.GameBoardSize; row++)
			{
				for (int col = 0; col < r_View.GameBoardSize; col++)
				{
					r_View.GameBoard[row, col] = r_Model.GetSymbol(new Point(row, col));
				}
			}
		}

		public void PrintBoard()
		{
			updateBoard();
			r_View.ClearScreen();
			r_View.PrintBoard();
		}
		
		public void EndGame()
		{
			r_View.EndGame();
		}
		*/
	}
}