#eg. 5C2
#super = 5;
#sub = 2;

def nCr(sup,sub):
    nom = 1
    denom = 1
    while(sub > 0):
        nom *= sup
        denom *= sub
	    
        sub -= 1
        sup -= 1
        
    return int(nom/denom)



#eg. pascal coefficient of 2 is [1 2 1]

def pascal_coeff(power):
    coeffs = []
    for i in range(power+1):
        coeffs.append(nCr(power,i))
	
    return coeffs
	


'''
0C0           1
1C0 1C1      1  1 
2C0 2C1 2C0 1  2  1
'''

def pascal_triangle(height):
    triangle = [[]]

    if height <= 0:
        return []
    
    for i in range(height+1):
        triangle.append(pascal_coeff(i))
        
    return triangle
