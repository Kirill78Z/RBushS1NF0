using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using RBushKnn;
using RBush;

namespace RBushKnn.Test
{
	public class KnnToLineSegmentTests
	{
		[Fact]
		public void SquaredDistanceToSegmentCorrect()
		{
			Box box = Box.CreateBox(new double[] { 6344, 3312.5, 6351.5, 3316 });

			double[] line = new double[] { 6347.5, 3317.5, 6352.5, 3312.5 };
			var distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6350, 3311.5, 6349.5, 3313.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6343, 3314.5, 6345.5, 3316.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6350.5, 3318.5, 6354, 3312 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 0.30477845766521439);

			line = new double[] { 6355, 3317, 6359, 3314.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 3.640054944640259);

			line = new double[] { 6343, 3314, 6337, 3314 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 1);

			line = new double[] { 6343, 3317, 6340.5, 3318 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 1.4142135623730952);

			line = new double[] { 6341, 3311, 6355, 3311 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 1.5);

			line = new double[] { 6341, 3312.5, 6345, 3311 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 1.0533703247653881);

			line = new double[] { 6356.5, 3318, 6356.5, 3309.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 5);

			line = new double[] { 6347, 3316.5, 6351, 3320.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 0.5);

			line = new double[] { 6338.5, 3319, 6350.5, 3321.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 4.058689656828709);

			line = new double[] { 6350, 3317, 6353, 3315 };
			distToSpatial = new LineSegmentDistanceToSpatial(box, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 0);



			Box point = Box.CreateBox(new double[] { 6365.5, 3314, 6365.5, 3314 });

			line = new double[] { 6365.5, 3314, 6367, 3315.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6365, 3315, 6366.5, 3312 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6365.5, 3315, 6365.5, 3317.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 1);

			line = new double[] { 6365, 3314.5, 6364, 3314.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 0.70710678118654757);

			line = new double[] { 6364.5, 3314, 6366, 3313 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 0.55470019622535527);

			line = new double[] { 6366, 3315.5, 6367, 3313 };
			distToSpatial = new LineSegmentDistanceToSpatial(point, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox) == 1.0213243599736164);


			Box hor = Box.CreateBox(new double[] { 6372, 3314, 6375.5, 3314 });

			line = new double[] { 6374, 3315, 6375.5, 3313 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6372, 3316, 6372, 3314 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6375.5, 3314, 6377.5, 3314 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(distToSpatial.SquaredDistanceToBox == 0);

			line = new double[] { 6373, 3314.5, 6374, 3315.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(0.5));

			line = new double[] { 6371.5, 3313.5, 6370.5, 3313.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(0.70710678));

			line = new double[] { 6372.5, 3313, 6374, 3313 };
			distToSpatial = new LineSegmentDistanceToSpatial(hor, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(1));


			Box vert = Box.CreateBox(new double[] { 6381, 3315, 6381, 3313 });

			line = new double[] { 6382, 3314, 6380, 3313.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(vert, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(0));

			line = new double[] { 6380.5, 3316.5, 6382, 3315.5 };
			distToSpatial = new LineSegmentDistanceToSpatial(vert, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(0.97072534));

			line = new double[] { 6381, 3311.5, 6382, 3310 };
			distToSpatial = new LineSegmentDistanceToSpatial(vert, line[0], line[1], line[2], line[3]);
			Assert.True(Math.Sqrt(distToSpatial.SquaredDistanceToBox).AlmostEquals(1.5));
		}


		static double[,] data =
		{
			{6377.5, 3330.5, 6380.0, 3332.5}, {6374.5, 3333.5, 6375.0, 3335.5}, {6371.5, 3332.0, 6373.5, 3333.0},
			{6362.5, 3329.5, 6369.0, 3332.5}, {6374.5, 3327.0, 6380.5, 3329.5}, {6385.0, 3332.5, 6388.0, 3335.0},
			{6388.5, 3338.5, 6390.5, 3342.5}, {6379.5, 3336.0, 6381.5, 3339.0}, {6375.5, 3339.5, 6377.5, 3342.0},
			{6364.0, 3354.0, 6364.0, 3354.0}, {6362.5, 3353.5, 6362.5, 3353.5}, {6361.0, 3352.5, 6361.0, 3352.5},
			{6363.0, 3351.0, 6363.0, 3351.0}, {6365.0, 3351.5, 6365.0, 3351.5}, {6363.5, 3352.0, 6363.5, 3352.0},
			{6379.5, 3343.5, 6382.0, 3349.0}, {6372.5, 3347.5, 6377.0, 3348.0}, {6378.5, 3348.5, 6379.5, 3351.0},
			{6378.0, 3345.5, 6379.5, 3348.0}, {6375.5, 3348.5, 6378.0, 3350.0}, {6375.0, 3344.0, 6377.5, 3347.0},
			{6371.0, 3336.5, 6372.0, 3340.0}, {6367.0, 3342.0, 6368.0, 3344.0}, {6364.5, 3340.5, 6368.0, 3341.0},
			{6360.5, 3340.0, 6361.5, 3342.0}, {6361.0, 3339.0, 6363.0, 3340.0}, {6363.5, 3337.5, 6365.0, 3340.0},
			{6357.0, 3342.0, 6363.5, 3343.0}, {6364.0, 3342.0, 6365.0, 3344.5}, {6359.0, 3343.0, 6362.5, 3345.0},
			{6362.0, 3340.5, 6363.0, 3341.5}, {6358.5, 3337.5, 6360.5, 3341.5}
		};



		static Box[] boxes =
			Box.CreateBoxes(data);

		[Fact]
		public void FindsNNeighbors1()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(boxes);
			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6362, 3343.5, 6360.75, 3344, 10);
			Box[] mustBeReturned = Box.CreateBoxes(new double[,]
			{{6359.0, 3343.0, 6362.5, 3345.0}, {6357.0, 3342.0, 6363.5, 3343.0}, {6360.5, 3340.0, 6361.5, 3342.0},
			{6364.0, 3342.0, 6365.0, 3344.5}, {6362.0, 3340.5, 6363.0, 3341.5},{6358.5, 3337.5, 6360.5, 3341.5},
			{6361.0, 3339.0, 6363.0, 3340.0},{6364.5, 3340.5, 6368.0, 3341.0},{6363.5, 3337.5, 6365.0, 3340.0},
			{6367.0, 3342.0, 6368.0, 3344.0},
			});
			Assert.True(mustBeReturned.Length == result.Count());


			Assert.True(result.ElementAt(0).CompareTo(mustBeReturned[0]) == 0);
			Assert.True(result.ElementAt(1).CompareTo(mustBeReturned[1]) == 0);
			Assert.True(result.ElementAt(2).CompareTo(mustBeReturned[2]) == 0);
			Assert.True(result.ElementAt(3).CompareTo(mustBeReturned[3]) == 0
				|| result.ElementAt(3).CompareTo(mustBeReturned[4]) == 0);
			Assert.True(result.ElementAt(4).CompareTo(mustBeReturned[3]) == 0
				|| result.ElementAt(4).CompareTo(mustBeReturned[4]) == 0);
			Assert.True(result.ElementAt(5).CompareTo(mustBeReturned[5]) == 0);

			Assert.True(result.ElementAt(6).CompareTo(mustBeReturned[6]) == 0);
			Assert.True(result.ElementAt(7).CompareTo(mustBeReturned[7]) == 0);
			Assert.True(result.ElementAt(8).CompareTo(mustBeReturned[8]) == 0);
			Assert.True(result.ElementAt(9).CompareTo(mustBeReturned[9]) == 0);
		}


		[Fact]
		public void FindsNNeighbors2()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(boxes);
			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6361.5, 3352.5, 6367, 3354, 6);
			Box[] mustBeReturned = Box.CreateBoxes(new double[,]
			{{6361.0, 3352.5, 6361.0, 3352.5}, {6362.5, 3353.5, 6362.5, 3353.5}, {6364.0, 3354.0, 6364.0, 3354.0},
			{6363.5, 3352.0, 6363.5, 3352.0}, {6363.0, 3351.0, 6363.0, 3351.0}, {6365.0, 3351.5, 6365.0, 3351.5},
			});

			Assert.True(mustBeReturned.Length == result.Count());
			Assert.True(result.ElementAt(0).CompareTo(mustBeReturned[0]) == 0);
			Assert.True(result.ElementAt(1).CompareTo(mustBeReturned[1]) == 0);
			Assert.True(result.ElementAt(2).CompareTo(mustBeReturned[2]) == 0);
			Assert.True(result.ElementAt(3).CompareTo(mustBeReturned[3]) == 0);
			Assert.True(result.ElementAt(4).CompareTo(mustBeReturned[4]) == 0);
			Assert.True(result.ElementAt(5).CompareTo(mustBeReturned[5]) == 0);
		}

		[Fact]
		public void FindAllNeighborsForMaxDistance1()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(boxes);
			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6377.5, 3351.5, 6379, 3350.5, 0, maxDist: 4);
			Box[] mustBeReturned = Box.CreateBoxes(new double[,]
			{
				{6378.5, 3348.5, 6379.5, 3351.0}, {6375.5, 3348.5, 6378.0, 3350.0}, {6379.5, 3343.5, 6382.0, 3349.0},
				{6378.0, 3345.5, 6379.5, 3348.0}, {6372.5, 3347.5, 6377.0, 3348.0}, {6375.0, 3344.0, 6377.5, 3347.0},
			});

			Assert.True(mustBeReturned.Length == result.Count());
			Assert.True(result.ElementAt(0).CompareTo(mustBeReturned[0]) == 0);
			Assert.True(result.ElementAt(1).CompareTo(mustBeReturned[1]) == 0);
			Assert.True(result.ElementAt(2).CompareTo(mustBeReturned[2]) == 0);
			Assert.True(result.ElementAt(3).CompareTo(mustBeReturned[3]) == 0);
			Assert.True(result.ElementAt(4).CompareTo(mustBeReturned[4]) == 0);
			Assert.True(result.ElementAt(5).CompareTo(mustBeReturned[5]) == 0);
		}


		[Fact]
		public void FindAllNeighborsForMaxDistance2()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(boxes);
			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6373, 3324, 6396.5, 3336, 0, maxDist: 8);
			Box[] mustBeReturned = Box.CreateBoxes(new double[,]
			{
				{6374.5, 3327.0, 6380.5, 3329.5}, {6385.0, 3332.5, 6388.0, 3335.0}, {6377.5, 3330.5, 6380.0, 3332.5},
				{6388.5, 3338.5, 6390.5, 3342.5}, {6362.5, 3329.5, 6369.0, 3332.5}, {6379.5, 3336.0, 6381.5, 3339.0},
				{6371.5, 3332.0, 6373.5, 3333.0}, {6374.5, 3333.5, 6375.0, 3335.5},
			});

			Assert.True(mustBeReturned.Length == result.Count());
			Assert.True(result.ElementAt(0).CompareTo(mustBeReturned[0]) == 0);
			Assert.True(result.ElementAt(1).CompareTo(mustBeReturned[1]) == 0);
			Assert.True(result.ElementAt(2).CompareTo(mustBeReturned[2]) == 0);
			Assert.True(result.ElementAt(3).CompareTo(mustBeReturned[3]) == 0);
			Assert.True(result.ElementAt(4).CompareTo(mustBeReturned[4]) == 0);
			Assert.True(result.ElementAt(5).CompareTo(mustBeReturned[5]) == 0);
			Assert.True(result.ElementAt(6).CompareTo(mustBeReturned[6]) == 0);
		}

		[Fact]
		public void FindNNeighborsForMaxDistance()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(boxes);
			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6373, 3324, 6396.5, 3336, 3, maxDist: 8);
			Box[] mustBeReturned = Box.CreateBoxes(new double[,]
			{
				{6374.5, 3327.0, 6380.5, 3329.5}, {6385.0, 3332.5, 6388.0, 3335.0}, {6377.5, 3330.5, 6380.0, 3332.5}
			});

			Assert.True(mustBeReturned.Length == result.Count());
			Assert.True(result.ElementAt(0).CompareTo(mustBeReturned[0]) == 0);
			Assert.True(result.ElementAt(1).CompareTo(mustBeReturned[1]) == 0);
			Assert.True(result.ElementAt(2).CompareTo(mustBeReturned[2]) == 0);
		}




		static Box[] richData
			= Box.CreateBoxes((new double[,]
			{
				{6387.5, 3349.5, 6389.5, 3352.0}, {6390.0, 3350.5, 6391.5, 3353.5}, {6393.8, 3354.0, 6395.3, 3356.0},
				{6388.5, 3346.0, 6390.5, 3348.5}, {6391.0, 3347.5, 6393.0, 3349.5}, {6393.5, 3345.0, 6395.5, 3348.5},
			}));

		static KnnToLineSegmentTests()
		{
			for (int i = 0; i < richData.Length; i++)
			{
				richData[i].Version = i + 1;
			}
		}

		[Fact]
		public void FindNeighborsThatSatisfyAGivenPredicate()
		{
			RBush<Box> bush = new RBush<Box>();
			bush.BulkLoad(richData);

			IEnumerable<Box> result = bush.KnnToLineSegmentSearch(6386.5, 3349.5, 6393, 3353.5, 1, b => b.Version > 2);

			if (result.Count() == 1)
			{
				Box item = result.First();
				if (item.Envelope.MinX == 6393.8 && item.Envelope.MinY == 3354.0
					&& item.Envelope.MaxX == 6395.3 && item.Envelope.MaxY == 3356.0
					&& item.Version == 3)
				{
					//Test passes. Found the correct item
				}
				else
				{
					Assert.True(false, "Could not find the correct item");
				}
			}
			else
			{
				Assert.True(false, "Could not find the correct item");
			}

		}
	}

	public static class DoubleExt
	{
		public static bool AlmostEquals(this double d, double other)
		{
			return Math.Abs(d - other) <= 1E-8;
		}
	}
}
