//This function returns the quantity of odd numbers in an array.
function evenAndOdd(n){

    i = 0
    odd = []

    // loop through the array to veify.
    while( i < n.length){
        //verify if the number is odd
        if(n[i]%2 != 0){
            odd.push(n[i])
        }
        i ++
    }

    return odd.length
}

console.log('final result:', evenAndOdd([1, 2, 3, 4, 5, 6, 7, 8, 11, 235, 65789]))