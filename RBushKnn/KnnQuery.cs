using System;
using System.Collections.Generic;
using System.Text;

namespace RBushKnn
{
	internal class KnnToPointQuery 
	{
		public double X { get; set; }
		public double Y { get; set; }
	}


	internal class KnnToLineSegmentQuery
	{
		public double X0 { get; set; }
		public double Y0 { get; set; }

		public double X1 { get; set; }
		public double Y1 { get; set; }
	}
}
