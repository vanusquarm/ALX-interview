def fibonacci(n):
   "
   List n terms of fibonacci series
   :params: Number of terms
   :return: list: fibonacci series
   "
    start = [1,2]
    for i in range(n-2):
        start.append(sum(start[-2:]))
        
    return start
