namespace B18Ex05.Checkers.Model
{
	public class Point
	{
		private			int		x;
		private			int		y;

		public					Point()
		{
			x = 0;
			y = 0;
		}

		public	static	Point	operator +(Point point1, Point point2)
		{
			return new Point(point1.X + point2.X, point1.Y + point2.Y);
		}

		public	static	Point	operator -(Point point1, Point point2)
		{
			return new Point(point1.X - point2.X, point1.Y - point2.Y);
		}
	
		public	static	Point	operator /(Point point1, int i_Divisor)
		{
			return new Point(point1.X / i_Divisor, point1.Y / i_Divisor);
		}

		public					Point(int i_x, int i_y)
		{
			X = i_x;
			Y = i_y;
		}

		public			int		X
		{
			get
			{
				return x;
			}

			set
			{
				x = value;
			}
		}

		public			int		Y
		{
			get
			{
				return y;
			}

			set
			{
				y = value;
			}
		}

		public			void	UpdateCoordinates(int i_x, int i_y)
		{
			X = i_x;
			Y = i_y;
		}
	}
}
