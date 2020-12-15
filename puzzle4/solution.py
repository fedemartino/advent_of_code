##255<answer<264
##185>answer
import re

fieldValidators = {
    "byr" : "([2][0][0][012])|([1][9][2-9][0-9])",
    "iyr" : "[2][0][1-2][0-9]",
    "eyr" : "[2][0](([2][0-9])|([3][0]))",
    "hgt" : "([1](([5-8][0-9])|([9][0-3]))[c][m])|((([5][9])|([6][0-9])|([7][0-6]))[i][n])",
    "hcl" : "[#]([0-9]|[a-f]){6}",
    "ecl" : "(^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$)",
    "pid" : "[0-9]{9}"
}

def run(input, mandatoryFields):
    validPassportCount = 0
    for line in input.split("\n\n"):
        validPass = isValidPassport(line, mandatoryFields)
        if (validPass):
            validPassportCount+=1
    return validPassportCount

def isValidPassport(passport, mandatoryFields):
    hasFields = True
    for field in mandatoryFields:
        fieldIndex = passport.find(field)
        if (fieldIndex!=-1):
            value = passport[fieldIndex:].split("\n")[0].split(" ")[0].split(":")[1].strip()
            if (not isValidField(field, value)):
                return False
            if (isValidField(field, value)):
                print("field: " + field + " value : " + value + " " + str(isValidField(field, value)))
        else:
            return False
    return hasFields

def isValidField(field, value):
    reg = fieldValidators[field]
    return re.match(reg, value) != None
