
def run(input, depth, goal):
    return runrecursive(input, depth, goal)

def runrecursive(input, depth, goal):
    if (depth > 1):
        for i in range(len(input)-depth):
            value = int(input[i])
            val2 = runrecursive(input[i+1:],depth-1, goal-value)
            if (val2 != 0):
                return val2*value
    else:
        for i in range(len(input)-1):
            value1 = int(input[i])
            for value2 in input[i+1:]:
                if (value1 + int(value2))==goal:
                    return value1 * int(value2)
    return 0