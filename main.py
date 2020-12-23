from extract.extractdata import extract, extractRaw
from puzzle1.solution import run as puzzle1
from puzzle2.solution import solution_v1, solution_v2
from puzzle3.solution import run as puzzle3
from puzzle4.solution import run as puzzle4
from puzzle5.solution import run as puzzle5
from puzzle6.solution import run as puzzle6
from puzzle7.solution import run as puzzle7
from puzzle8.solution import run as puzzle8
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
    answer1, answer2 = puzzle8(input, 'shiny gold')
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
puzzle8Solution()
#puzzle9Solution()
#puzzle10Solution()
#puzzl11Solution()
#puzzle12Solution()