// C++ program for the above approach

#include <bits/stdc++.h>
using namespace std;

// Function to check possible RBS from
// the given strings
int checkRBS(vector<string> S)
{
	int N = S.size();

	// Stores the values {sum, min_prefix}
	vector<pair<int, int> > v(N);

	// Iterate over the range
	for (int i = 0; i < N; ++i) {
		string s = S[i];

		// Stores the total sum
		int sum = 0;

		// Stores the minimum prefix
		int pre = 0;
		for (char c : s) {
			if (c == '(') {
				++sum;
			}
			else {
				--sum;
			}

			// Check for minimum prefix
			pre = min(sum, pre);
		}

		// Store these values in vector
		v[i] = { sum, pre };
	}

	// Make two pair vectors pos and neg
	vector<pair<int, int> > pos;
	vector<pair<int, int> > neg;

	// Store values according to the
	// mentioned approach
	for (int i = 0; i < N; ++i) {
		if (v[i].first >= 0) {
			pos.push_back(
				{ -v[i].second, v[i].first });
		}
		else {
			neg.push_back(
				{ v[i].first - v[i].second,
				-v[i].first });
		}
	}

	// Sort the positive vector
	sort(pos.begin(), pos.end());

	// Stores the extra count of
	// open brackets
	int open = 0;
	for (auto p : pos) {
		if (open - p.first >= 0) {
			open += p.second;
		}

		// No valid bracket sequence
		// can be formed
		else {
			cout << "No"
				<< "\n";
			return 0;
		}
	}

	// Sort the negative vector
	sort(neg.begin(), neg.end());

	// Stores the count of the
	// negative elements
	int negative = 0;
	for (auto p : neg) {

		if (negative - p.first >= 0) {
			negative += p.second;
		}

		// No valid bracket sequence
		// can be formed
		else {
			cout << "No\n";
			return 0;
		}
	}

	// Check if open is equal to negative
	if (open != negative) {
		cout << "No\n";
		return 0;
	}
	cout << "Yes\n";
	return 0;
}

// Driver Code
int main()
{
	vector<string> arr = { ")", "()(" };
	checkRBS(arr);

	return 0;
}
