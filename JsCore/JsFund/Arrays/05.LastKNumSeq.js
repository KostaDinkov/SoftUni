function lastKnum(n,k){
    var result = [1];

   for (let i = 1; i < n ; i++) {
     result[i] = getSumK(result,i-1,k)
   }

   function getSumK(arr,index,k) {
       if(index<0 || k==0){
           return 0;
       }
       return arr[index]+ getSumK(arr,index-1,k-1)
   }
   return result;
}

console.log(lastKnum(8, 2));
