// C# program for the above approach
using System;
using System.Collections.Generic;

public class GFG{
class pair : IComparable<pair>
	{
		public int first,second;
		public pair(int first, int second)
		{
			this.first = first;
			this.second = second;
		}

		public int CompareTo(pair p)
		{
			return this.first - p.first;
		}
	}

// Function to check possible RBS from
// the given Strings
static int checkRBS(String[] S)
{
	int N = S.Length;

	// Stores the values {sum, min_prefix}
	pair []v = new pair[N];

	// Iterate over the range
	for (int i = 0; i < N; ++i) {
		String s = S[i];

		// Stores the total sum
		int sum = 0;

		// Stores the minimum prefix
		int pre = 0;
		foreach (char c in s.ToCharArray()) {
			if (c == '(') {
				++sum;
			}
			else {
				--sum;
			}

			// Check for minimum prefix
			pre = Math.Min(sum, pre);
		}

		// Store these values in vector
		v[i] = new pair( sum, pre );
	}

	// Make two pair vectors pos and neg
	List<pair> pos = new List<pair>();
	List<pair > neg = new List<pair>();

	// Store values according to the
	// mentioned approach
	for (int i = 0; i < N; ++i) {
		if (v[i].first >= 0) {
			pos.Add(
				new pair( -v[i].second, v[i].first ));
		}
		else {
			neg.Add(
					new pair( v[i].first - v[i].second,
				-v[i].first ));
		}
	}

	// Sort the positive vector
	pos.Sort();

	// Stores the extra count of
	// open brackets
	int open = 0;
	foreach (pair p in pos) {
		if (open - p.first >= 0) {
			open += p.second;
		}

		// No valid bracket sequence
		// can be formed
		else {
			Console.Write("No"
				+ "\n");
			return 0;
		}
	}

	// Sort the negative vector
	neg.Sort();

	// Stores the count of the
	// negative elements
	int negative = 0;
	foreach (pair p in neg) {

		if (negative - p.first >= 0) {
			negative += p.second;
		}

		// No valid bracket sequence
		// can be formed
		else {
			Console.Write("No\n");
			return 0;
		}
	}

	// Check if open is equal to negative
	if (open != negative) {
		Console.Write("No\n");
		return 0;
	
	}
	Console.Write("Yes\n");
	return 0;
}

// Driver Code
public static void Main(String[] args)
{
	String []arr = { ")", "()(" };
	checkRBS(arr);

}
}

// This code is contributed by 29AjayKumar
