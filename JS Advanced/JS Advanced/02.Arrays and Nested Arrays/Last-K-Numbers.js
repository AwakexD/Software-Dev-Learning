function Solve (n, k) {
    const sequence = [1]; // Start with the first element, which is always 1
  
    for (let i = 1; i < n; i++) {
      // Calculate the sum of the previous k elements
      const sum = sequence.slice(Math.max(0, i - k), i).reduce((acc, num) => acc + num, 0);
      
      sequence.push(sum); // Add the sum to the sequence
    }
  
    return sequence;
}

Solve(6, 3)