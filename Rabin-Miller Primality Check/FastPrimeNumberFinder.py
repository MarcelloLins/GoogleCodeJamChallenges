# Implementation of the Miller-Rabin Pseudo-Primality Check
# that uses numbers as witnesses of the primality of the main number
# https://en.wikipedia.org/wiki/Miller%E2%80%93Rabin_primality_test?oldformat=true

from random import randrange

# N = Number to be checked
# A = Witness
def IsRabinMillerStrongPseudoPrime(n, w):
    d, s = n-1, 0
    
    # Multiple Divisions by two to obtain both D and S factors
    while d % 2 == 0:
        d, s = d/2, s+1

    # T = (W**D) % N        
    t = pow(w, d, n)
    
    # First check of the RabinMiller Algorithm
    if t == 1:
        return True
        
    # Second Check Set
    while s > 0:
    
        if t == n - 1:
            return True
            
        # T = (T**2) % N
        # S = S - 1
        t, s = pow(t, 2, n), s - 1
    return False

def isPrime(n, k):
    # Obvious cases - No Even Number is Prime but two
    if n % 2 == 0:
        return n == 2
    
    # Random K witnesses in a range from 2 to N-1
    for _ in range(1, k):
    
        # W = Current Witness
        w = randrange(2, n)
        
        # PseudoPrimality Check
        if not IsRabinMillerStrongPseudoPrime(n, w):
            return False
    return True 
    
if __name__ == '__main__':
    print '%s' % isPrime(13,4)
    print '%s' % isPrime(271,30)
    print '%s' % isPrime(719,30)
    print '%s' % isPrime(15,3)