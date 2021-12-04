accInstr = "acc"
jmpInstr = "jmp"
nopInstr = "nop"

def run(input):
    part1, end = executeProgram(input)
    #print("End: " + str(end))
    oldParam = ""
    part2 = 0
    print("start part 2")
    for i in range(len(input)):
        instruction = input[i]
        oldParam = instruction
        argument, parameter = getInstruction(instruction)
        if (argument==jmpInstr):
            input[i] = nopInstr + " " + str(parameter)
        elif (argument==nopInstr):
            input[i] = jmpInstr + " " + str(parameter)
        #print("new input")
        #print(i)
        #print(input[i])
        #print("new program")
        #print(input)
        #print(input)
        acc, end = executeProgram(input)
        #print(acc)
        #print(end)
        if (end):
            part2 = acc
            print("END")
            break
        else:
            input[i] = oldParam
    
    return part1, part2

def executeProgram(input):
    executed =  [False for i in range(len(input))] 
    accumulator = 0
    i = 0
    while(i<len(executed) and not executed[i]):
        executed[i] = True
        argument, parameter = getInstruction(input[i])
        if (argument == nopInstr):
            i+=1
        elif (argument == accInstr):
            accumulator += parameter
            i+=1
        elif (argument == jmpInstr):
            i += parameter
    return accumulator, i==len(executed)

def getInstruction(instruction):
    #print(instruction)
    splitInstruction = instruction.split(" ")
    argument = splitInstruction[0]
    parameter = int(splitInstruction[1])
    return argument, parameter