using RBush;
using System;
using System.Collections.Generic;

namespace RBushKnn
{
	public static class KnnSearchExtension
	{
		public static IReadOnlyList<T> KnnToPointSearch<T>(this RBush<T> tree, double x, double y, int n,
			Func<T, bool> predicate = null, double maxDist = -1) where T : ISpatialData
		{
			return tree.KnnSearch(new KnnToPointQuery { X = x, Y = y }, n, predicate, maxDist);
		}

		public static IReadOnlyList<T> KnnToLineSegmentSearch<T>(this RBush<T> tree,
			double x0, double y0, double x1, double y1, int n, Func<T, bool> predicate = null, double maxDist = -1)
			where T : ISpatialData
		{
			return tree.KnnSearch(new KnnToLineSegmentQuery { X0 = x0, Y0 = y0, X1 = x1, Y1 = y1 }, n, predicate, maxDist);
		}

		internal static IReadOnlyList<T> KnnSearch<T>(this RBush<T> tree, object query, int n,
			Func<T, bool> predicate = null, double maxDist = -1) where T : ISpatialData
		{
			var distCalculator = new DistanceToSpatialCalculator();

			if (maxDist > 0)
				maxDist = maxDist * maxDist;//compare quadratic distances

			List<T> result = new List<T>();

			//priority queue
			var queue = new C5.IntervalHeap<IDistanceToSpatial>(new DistComparer());

			RBush<T>.Node node = tree.Root;

			while (node != null)
			{
				foreach (ISpatialData child in node.Children)//for each child
				{
					var childDistData = distCalculator.CalculateDistanceToSpatial(query, child);//calc distance to box
					if (maxDist < 0 || childDistData.SquaredDistanceToBox <= maxDist)//check if distance less than max distance
						queue.Add(childDistData);//add to queue
				}

				//dequeue all objects that are items stored in RBush
				while (queue.Count > 0 && queue.FindMin().SpatialData is T)
				{
					var candidateWr = queue.DeleteMin();//this item goes to result
					T candidate = (T)candidateWr.SpatialData;
					if (predicate == null || predicate.Invoke(candidate))//if element satisfy the condition
						result.Add(candidate);//add to result
					if (n > 0 && result.Count == n)//if the desired amount is already in the result
						return result;//return result
				}

				//process next element in queue
				if (queue.Count > 0)
					node = queue.DeleteMin().SpatialData as RBush<T>.Node;
				else
					node = null;
			}

			return result;
		}



		private class DistComparer : IComparer<IDistanceToSpatial>
		{
			public int Compare(IDistanceToSpatial n1, IDistanceToSpatial n2)
			{
				return n1.SquaredDistanceToBox.CompareTo(n2.SquaredDistanceToBox);
			}

		}
	}
}
