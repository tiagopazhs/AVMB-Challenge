function verifyIsPalindrome(a) {
    return a === a.split('').reverse().join('');
}

console.log(verifyIsPalindrome("reviver"));
console.log(verifyIsPalindrome("revive")); 
