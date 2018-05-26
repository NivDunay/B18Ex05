using System.Drawing;
using System.Windows.Forms;

namespace B18Ex05.Checkers.View
{
	public class GameBoardSquare : Button
	{
		private readonly Point r_Location;

		public GameBoardSquare(Point i_Location)
		{
			Name       = i_Location.ToString();
			Text       = "";
			r_Location = i_Location;
			Height     = Constants.k_ButtonHeight;
			Width      = Constants.k_ButtonWidth;
			BackColor  = Color.White;
		}
	}
}