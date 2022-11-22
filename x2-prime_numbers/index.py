#!bin/usr
"""
  Prime numbers
"""



def prime_numbers(n): #prime numbers less than n
    prime_list = [2] # all prime numbers are odd except 2
    
    for i in range(1, n//2):
        odd_num = 2*i + 1 # odd number
        flag = True # is prime
        for j in prime_list:
            # checking if odd number already has factors in prime_list
            if odd_num%j == 0: # if True, then
                flag = False # not prime
        if(flag):
            prime_list.append(odd_num)
        
    
    return prime_list

print(prime_numbers(100))
