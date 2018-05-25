using System.Collections.Generic;
using System.Drawing;

namespace B18Ex05.Checkers.Model
{
	public class Game
	{
		private const int k_KingScore = 4;
		private const int k_PawnScore = 1;

		private          GameBoard       m_Board;
		private readonly Player[]        r_Players = new Player[2];
		private          int             m_PlayerTurn;
		private          GamePiece       m_PieceToMove;
		private readonly List<PieceMove> r_CurrentTurnPossibleMoves = new List<PieceMove>(2);
		private          bool            m_WasPieceEaten;
		private          bool            m_IsGameOver;
		private          bool            m_DidPlayerQuit;

		public bool IsCurrentPlayerComputer()
		{
			return r_Players[m_PlayerTurn].IsComputer;
		}

		private void clearPlayerPieces(Player i_Player)
		{
			foreach (GamePiece currentPiece in i_Player.GamePieces)
			{
				m_Board.Board[currentPiece.Location.Y, currentPiece.Location.X] = null;
			}

			i_Player.GamePieces.Clear();
		}

		public void ResetGameData()
		{
			clearBoard();
			resetGameFlags();
			m_Board.InitializeBoard(r_Players[0], r_Players[1]);
		}

		private void clearBoard()
		{
			clearPlayerPieces(r_Players[0]);
			clearPlayerPieces(r_Players[1]);
		}

		private void resetGameFlags()
		{
			m_PlayerTurn    = 0;
			m_IsGameOver    = false;
			m_DidPlayerQuit = false;
			m_WasPieceEaten = false;
		}

		public bool DidPlayerQuit
		{
			get { return m_DidPlayerQuit; }

			set { m_DidPlayerQuit = value; }
		}

		public bool IsGameOver
		{
			get { return m_IsGameOver; }

			set { m_IsGameOver = value; }
		}

		public List<string> GetCurrentMoves()
		{
			List<string> currentMoves = new List<string>(r_CurrentTurnPossibleMoves.Count);
			foreach (PieceMove currentMove in r_CurrentTurnPossibleMoves)
			{
				currentMoves.Add(string.Format("{0}>{1}", locationToString(currentMove.Location),
					locationToString(currentMove.Destination)));
			}

			return currentMoves;
		}

		public int CurrentPlayerTurn
		{
			get { return m_PlayerTurn; }
		}

		public bool WasPieceEaten
		{
			get { return m_WasPieceEaten; }

			set { m_WasPieceEaten = value; }
		}

		private string locationToString(Point i_Location)
		{
			return string.Format("{0}{1}", (char) (i_Location.X + 'A'), (char) (i_Location.Y + 'a'));
		}

		public string GetPlayerName(int i_PlayerNumber)
		{
			return r_Players[i_PlayerNumber].Name;
		}

		public char GetPlayerSymbol(int i_PlayerNumber)
		{
			return r_Players[i_PlayerNumber].GamePieceSymbol;
		}

		public bool FindPlayersFirstMoves(int i_PlayerNumber)
		{
			r_CurrentTurnPossibleMoves.Clear();
			foreach (GamePiece currentPiece in r_Players[i_PlayerNumber].GamePieces)
			{
				r_CurrentTurnPossibleMoves.AddRange(m_Board.FindPossibleEatingMoves(currentPiece));
			}

			if (r_CurrentTurnPossibleMoves.Count == 0)
			{
				foreach (GamePiece currentPiece in r_Players[i_PlayerNumber].GamePieces)
				{
					r_CurrentTurnPossibleMoves.AddRange(m_Board.FindPossibleSteppingForwardMoves(currentPiece));
				}
			}

			return r_CurrentTurnPossibleMoves.Count != 0;
		}

		public bool FindPlayersContinuationMoves()
		{
			r_CurrentTurnPossibleMoves.Clear();
			r_CurrentTurnPossibleMoves.AddRange(m_Board.FindPossibleEatingMoves(m_PieceToMove));
			return r_CurrentTurnPossibleMoves.Count != 0;
		}

		public void MakePlayerMove(int i_PieceMoveIndex)
		{
			if (m_PieceToMove == null)
			{
				m_PieceToMove = m_Board.Board[r_CurrentTurnPossibleMoves[i_PieceMoveIndex].Location.Y,
					r_CurrentTurnPossibleMoves[i_PieceMoveIndex].Location.X];
			}

			if (r_CurrentTurnPossibleMoves[i_PieceMoveIndex].DoesEat)
			{
				eatPiece(m_Board.FindEatenPiece(r_CurrentTurnPossibleMoves[i_PieceMoveIndex]));
				m_WasPieceEaten = true;
			}

			movePiece(r_CurrentTurnPossibleMoves[i_PieceMoveIndex].Destination);
		}

		public void CheckAndMakeKing()
		{
			if (m_PieceToMove != null)
			{
				if (m_PieceToMove.Owner == r_Players[0])
				{
					if (m_PieceToMove.Location.Y == m_Board.Size - 1)
					{
						m_PieceToMove.MakeKing();
					}
				}
				else
				{
					if (m_PieceToMove.Location.Y == 0)
					{
						m_PieceToMove.MakeKing();
					}
				}
			}
		}

		private void movePiece(Point i_Destination)
		{
			m_Board.Board[i_Destination.Y, i_Destination.X]                   = m_PieceToMove;
			m_Board.Board[m_PieceToMove.Location.Y, m_PieceToMove.Location.X] = null;
			m_PieceToMove.Location                                            = i_Destination;
		}

		private void eatPiece(GamePiece i_EatenPiece)
		{
			r_Players[OtherPlayer()].RemoveGamePiece(i_EatenPiece);
			m_Board.Board[i_EatenPiece.Location.Y, i_EatenPiece.Location.X] = null;
		}

		public void EndTurn()
		{
			m_WasPieceEaten = false;
			m_PieceToMove   = null;
			m_PlayerTurn    = OtherPlayer();
		}

		public int OtherPlayer()
		{
			int secondPlayer;
			if (m_PlayerTurn == 0)
			{
				secondPlayer = 1;
			}
			else
			{
				secondPlayer = 0;
			}

			return secondPlayer;
		}

		public int BoardSize
		{
			get { return m_Board.Size; }
		}

		public void InitializePlayerOne(string i_Name)
		{
			r_Players[0] = new Player(i_Name, 'O', 'U', Player.eDirection.Down, false);
		}

		public void InitializePlayerTwo(string i_Name, bool i_IsComputer)
		{
			r_Players[1] = new Player(i_Name, 'X', 'K', Player.eDirection.Up, i_IsComputer);
		}

		public void InitializeBoard(int i_BoardSize)
		{
			m_Board = new GameBoard(i_BoardSize);
			m_Board.InitializeBoard(r_Players[0], r_Players[1]);
		}

		public char GetSymbol(Point i_Coordinates)
		{
			return m_Board.GetSymbol(i_Coordinates);
		}

		public uint GetPlayerNumberOfPieces(int i_PlayerNumber)
		{
			return (uint) r_Players[i_PlayerNumber].GamePieces.Count;
		}

		public void SetPlayerScore(uint i_Score, int i_PlayerNumber)
		{
			r_Players[i_PlayerNumber].Score += i_Score;
		}

		public uint GetPlayerScore(int i_PlayerNumber)
		{
			return r_Players[i_PlayerNumber].Score;
		}

		public uint CalculatePlayerScore(int i_PlayerNumber)
		{
			uint playerScore = 0;
			foreach (GamePiece currentPiece in r_Players[i_PlayerNumber].GamePieces)
			{
				if (currentPiece.IsKing)
				{
					playerScore += k_KingScore;
				}
				else
				{
					playerScore += k_PawnScore;
				}
			}

			return playerScore;
		}
	}
}