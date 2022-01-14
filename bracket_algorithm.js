<script>
// Javascript program for the above approach

// Function to check possible RBS from
// the given strings
function checkRBS(S) {
let N = S.length;

// Stores the values {sum, min_prefix}
let v = new Array(N);

// Iterate over the range
for (let i = 0; i < N; ++i) {
	let s = S[i];

	// Stores the total sum
	let sum = 0;

	// Stores the minimum prefix
	let pre = 0;
	for (let c of s) {
	if (c == "(") {
		++sum;
	} else {
		--sum;
	}

	// Check for minimum prefix
	pre = Math.min(sum, pre);
	}

	// Store these values in vector
	v[i] = [sum, pre];
}

// Make two pair vectors pos and neg
let pos = [];
let neg = [];

// Store values according to the
// mentioned approach
for (let i = 0; i < N; ++i) {
	if (v[i][0] >= 0) {
	pos.push([-v[i][1], v[i][0]]);
	} else {
	neg.push([v[i][0] - v[i][1], -v[i][0]]);
	}
}

// Sort the positive vector
pos.sort((a, b) => a - b);

// Stores the extra count of
// open brackets
let open = 0;
for (let p of pos) {
	if (open - p[0] >= 0) {
	open += p[1];
	}

	// No valid bracket sequence
	// can be formed
	else {
	document.write("No" + "<br>");
	return 0;
	}
}

// Sort the negative vector
neg.sort((a, b) => a - b);

// Stores the count of the
// negative elements
let negative = 0;
for (let p of neg) {
	if (negative - p[0] >= 0) {
	negative += p[1];
	}

	// No valid bracket sequence
	// can be formed
	else {
	document.write("No<br>");
	return 0;
	}
}

// Check if open is equal to negative
if (open != negative) {
	document.write("No<br>");
	return 0;
}
document.write("Yes<br>");
return 0;
}

// Driver Code

let arr = [")", "()("];
checkRBS(arr);

// This code is contributed by gfgking.
</script>
