# Python 3 program for the above approach

# Function to check possible RBS from
# the given strings
def checkRBS(S):

	N = len(S)

	# Stores the values {sum, min_prefix}
	v = [0]*(N)

	# Iterate over the range
	for i in range(N):
		s = S[i]

		# Stores the total sum
		sum = 0

		# Stores the minimum prefix
		pre = 0
		for c in s:
			if (c == '('):
				sum += 1

			else:
				sum -= 1

			# Check for minimum prefix
			pre = min(sum, pre)

		# Store these values in vector
		v[i] = [sum, pre]

	pos = []
	neg = []

	# Store values according to the
	# mentioned approach
	for i in range(N):
		if (v[i][0] >= 0):
			pos.append(
				[-v[i][1], v[i][0]])

		else:
			neg.append(
				[v[i][0] - v[i][1],
				-v[i][0]])

	# Sort the positive vector
	pos.sort()

	# Stores the extra count of
	# open brackets
	open = 0
	for p in pos:
		if (open - p[0] >= 0):
			open += p[1]

		# No valid bracket sequence
		# can be formed
		else:
			print("No")

			return 0

	# Sort the negative vector
	neg.sort()

	# Stores the count of the
	# negative elements
	negative = 0
	for p in neg:

		if (negative - p[0] >= 0):
			negative += p[1]

		# No valid bracket sequence
		# can be formed
		else:
			print("No")
			return 0

	# Check if open is equal to negative
	if (open != negative):
		print("No")
		return 0

	print("Yes")

# Driver Code
if __name__ == "__main__":

	arr = [")", "()("]
	checkRBS(arr)

	# This code is contributed by ukasp.
