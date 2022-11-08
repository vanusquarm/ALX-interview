#!/usr/bin/python3


def pascal_triangle(height):
    """
	calculates and draws the graph for a pascal triangle using the combination approach
	[[1],
	[1,1],
	[1,2,1]]
    """
    triangle = []
    # check against neg height
    if height <= 0:
        return [[]]
    
    for h in range(height+1):
        coeffs = []
        
        # calculate pascal coeffs for each degree
        power = h
        for i in range(power + 1):
            sub = i
            sup = power
            nom = 1
            denom = 1
			
            # calculate nCr
            while( sub> 0):
                nom *= sup
                denom *= sub

                sub -= 1
                sup -= 1

            coeffs.append(int(nom/denom))

        triangle.append(coeffs)
        
    return triangle
