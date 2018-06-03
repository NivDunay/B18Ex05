using System.Collections.Generic;

namespace B18Ex05.Checkers.Model
{
	internal class Player
	{
		private readonly	string			r_Name;
		private readonly	char			r_GamePieceSymbol;
		private readonly	char			r_KingSymbol;
		private readonly	eDirection		r_Direction;
		private readonly	bool			r_IsComputer;
		private readonly	List<GamePiece> r_GamePieces = new List<GamePiece>();
		private				uint			m_Score;

		internal enum eDirection
		{
			Down = 1,
			Up = -1,
			Left = -1,
			Right = 1
		}

		public Player(string i_Name, char i_GamePieceSymbol, char i_KingSymbol, eDirection i_Direction, bool i_IsComputer)
		{
			r_Name = i_Name;
			r_GamePieceSymbol = i_GamePieceSymbol;
			r_KingSymbol = i_KingSymbol;
			r_Direction = i_Direction;
			r_IsComputer = i_IsComputer;
		}

		public eDirection Direction
		{
			get { return r_Direction; }
		}

		public eDirection ReverseDirection
		{
			get
			{
				eDirection reverseDirection = r_Direction == eDirection.Down ? eDirection.Up : eDirection.Down;
				return reverseDirection;
			}
		}

		public List<GamePiece> GamePieces
		{
			get { return r_GamePieces; }
		}

		public string Name
		{
			get { return r_Name; }
		}

		public uint Score
		{
			get { return m_Score; }

			set { m_Score = value; }
		}

		public char GamePieceSymbol
		{
			get { return r_GamePieceSymbol; }
		}

		public char KingSymbol
		{
			get { return r_KingSymbol; }
		}

		public void AddGamePiece(GamePiece i_NewPiece)
		{
			r_GamePieces.Add(i_NewPiece);
		}

		public void RemoveGamePiece(GamePiece i_PieceToRemove)
		{
			r_GamePieces.Remove(i_PieceToRemove);
		}

		public bool IsComputer
		{
			get { return r_IsComputer; }
		}
	}
}