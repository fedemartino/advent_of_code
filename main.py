from extract.extractdata import extract, extractRaw
from puzzle1.solution import run as puzzle1
from puzzle2.solution import solution_v1, solution_v2
from puzzle3.solution import run as puzzle3
from puzzle4.solution import run as puzzle4
import re

def puzzle1Solution():
    print("-------------- Puzzle 1 -----------")
    input = extract("./puzzle1/input.txt")
    print("Part 1 Solution:")
    print(puzzle1(input, 1, 2020))
    print("Part 2 Solution:")
    print(puzzle1(input, 2, 2020))

def puzzle2Solution():
    print("-------------- Puzzle 2 -----------")
    input = extract("./puzzle2/input.txt")
    print("Part 1 Solution:")
    print(solution_v1(input))
    print("Part 2 Solution:")
    print(solution_v2(input))

def puzzle3Solution():
    print("-------------- Puzzle 3 -----------")
    input = extract("./puzzle3/input.txt")
    print("Part 1 Solution:")
    print(puzzle3(input, [[3,1]]))
    print("Part 2 Solution:")
    print(puzzle3(input, [[1,1],[3,1],[5,1],[7,1],[1,2]]))

def puzzle4Solution():
    print("-------------- Puzzle 4 -----------")
    input = extractRaw("./puzzle4/input.txt")
    print("Part 1 Solution:")
    print(puzzle4(input, ["byr","iyr","eyr","hgt","hcl","ecl","pid"]))
    print("Part 2 Solution:")
    #print(puzzle4(input, [[1,1],[3,1],[5,1],[7,1],[1,2]]))

#puzzle1Solution()
#puzzle2Solution()
#puzzle3Solution()
puzzle4Solution()
#for met in ["a190cm","blu","brn", "gry", "grn", "hzl", "11oth111","ssothas"]:
#    for i in range(1):
        #result = re.match("([2][0][0][012])|([1][9][2-9][0-9])", str(i))
        #result = re.match("[2][0](([1][0-9])|([2][0]))", str(i))
        #result = re.match("[2][0](([2][0-9])|([3][0]))", str(i))
#        result = re.match("([1](([5-8][0-9])|([9][0-3]))[c][m])|((([5][9])|([6][0-9])|([7][0-6]))[i][n])", met)
        #result = re.match("[#]([0-9]|[a-f]){6}", met+str(i))
        #result = re.match("(^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$)", met)
        
        #print(met + str(i) + " : " + str(result))