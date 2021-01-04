from extract.extractdata import extract, extractRaw
from puzzle1.solution import run as puzzle1
from puzzle2.solution import solution_v1, solution_v2
from puzzle3.solution import run as puzzle3
from puzzle4.solution import run as puzzle4
from puzzle5.solution import run as puzzle5
from puzzle6.solution import run as puzzle6
from puzzle7.solution import run as puzzle7
from puzzle8.solution import run as puzzle8
from puzzle9.solution import run as puzzle9
from puzzle10.solution import run as puzzle10
from puzzle11.solution import run as puzzle11
#from puzzle12.solution import run as puzzle12
#from puzzle13.solution import run as puzzle13
#from puzzle14.solution import run as puzzle14
#from puzzle15.solution import run as puzzle15
#from puzzle16.solution import run as puzzle16
#from puzzle17.solution import run as puzzle17
#from puzzle18.solution import run as puzzle18
#from puzzle19.solution import run as puzzle19
#from puzzle20.solution import run as puzzle20
#from puzzle21.solution import run as puzzle21
#from puzzle22.solution import run as puzzle22
#from puzzle23.solution import run as puzzle23
#from puzzle24.solution import run as puzzle24
#from puzzle25.solution import run as puzzle25
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
    print(puzzle4(input, ["byr","iyr","eyr","hgt","hcl","ecl","pid"], False))
    print("Part 2 Solution:")
    print(puzzle4(input, ["byr","iyr","eyr","hgt","hcl","ecl","pid"], True))

def puzzle5Solution():
    print("-------------- Puzzle 5 -----------")
    input = extract("./puzzle5/input.txt")
    maxSeat, missingSeat = puzzle5(input)
    print("Part 1 Solution:")
    print(maxSeat)
    print("Part 2 Solution:")
    print(missingSeat)

def puzzle6Solution():
    print("-------------- Puzzle 6 -----------")
    input = extractRaw("./puzzle6/input.txt")
    anyAnswer, allAnswer = puzzle6(input)
    print("Part 1 Solution:")
    print(anyAnswer)
    print("Part 2 Solution:")
    print(allAnswer)

def puzzle7Solution():
    print("-------------- Puzzle 7 -----------")
    input = extract("./puzzle7/input.txt")
    answer1, answer2 = puzzle7(input, 'shiny gold')
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)

def puzzle8Solution():
    print("-------------- Puzzle 8 -----------")
    input = extract("./puzzle8/input.txt")
    answer1, answer2 = puzzle8(input)
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)

def puzzle9Solution():
    print("-------------- Puzzle 9 -----------")
    input = extract("./puzzle9/input.txt")
    answer1, answer2 = puzzle9(input, 25)
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)

def puzzle10Solution():
    print("-------------- Puzzle 10 -----------")
    input = extract("./puzzle10/input.txt")
    answer1, answer2 = puzzle10(input)
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)

def puzzle11Solution():
    print("-------------- Puzzle 11 -----------")
    input = extract("./puzzle11/input.txt")
    answer1, answer2 = puzzle11(input)
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)

def puzzle12Solution():
    print("-------------- Puzzle 12 -----------")
    input = extract("./puzzle12/input.txt")
    answer1, answer2 = puzzle11(input)
    print("Part 1 Solution:")
    print(answer1)
    print("Part 2 Solution:")
    print(answer2)


#puzzle1Solution()
#puzzle2Solution()
#puzzle3Solution()
#puzzle4Solution()
#puzzle5Solution()
#puzzle6Solution()
#puzzle7Solution()
#puzzle8Solution()
#puzzle9Solution()
#puzzle10Solution()
puzzle11Solution()
#puzzle12Solution()
#puzzle13Solution()
#puzzle14Solution()
#puzzle15Solution()
#puzzle16Solution()
#puzzle17Solution()
#puzzle18Solution()
#puzzle19Solution()
#puzzle20Solution()
#puzzle21Solution()
#puzzle22Solution()
#puzzle23Solution()
#puzzle24Solution()
#puzzle25Solution()