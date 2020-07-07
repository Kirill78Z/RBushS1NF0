using RBush;
using System;
using System.Collections.Generic;
using System.Text;

namespace RBushKnn
{
	internal class SpatialDataWrapper
	{
		public ISpatialData SpatialData { get; private set; }

		public double SquaredDistanceToBox { get; private set; }


		public SpatialDataWrapper(ISpatialData spatialData, double x, double y)
		{
			SpatialData = spatialData;
			CalcBoxSquaredDistToPoint(x, y);
		}

		private void CalcBoxSquaredDistToPoint(double x, double y)
		{
			double dx = AxisDistToPoint(x, SpatialData.Envelope.MinX, SpatialData.Envelope.MaxX);
			double dy = AxisDistToPoint(y, SpatialData.Envelope.MinY, SpatialData.Envelope.MaxY);
			SquaredDistanceToBox = dx * dx + dy * dy;
		}

		private double AxisDistToPoint(double k, double min, double max)
		{
			return k < min ? min - k : k <= max ? 0 : k - max;
		}


		
	}
}
