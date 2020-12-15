import re

fieldValidators = {
    "byr" : "(^200[012]$)|(^19[2-9][0-9]$)",
    "iyr" : "(^201[0-9]$)|(^2020$)",
    "eyr" : "(^202[0-9]$)|(^2030$)",
    "hgt" : "(((1[5-8][0-9])|(19[0-3]))cm)|(((59)|(6[0-9])|(7[0-6]))in)",
    "hcl" : "^#([0-9]|[a-f]){6}$",
    "ecl" : "(^amb$|^blu$|^brn$|^gry$|^grn$|^hzl$|^oth$)",
    "pid" : "^[0-9]{9}$"
}

def run(input, mandatoryFields, fieldValidation):
    validPassportCount = 0
    for line in input.split("\n\n"):
        validPass = isValidPassport(line, mandatoryFields, fieldValidation)
        if (validPass):
            validPassportCount+=1
    return validPassportCount

def isValidPassport(passport, mandatoryFields, fieldValidation):
    hasFields = True
    for field in mandatoryFields:
        fieldIndex = passport.find(field)
        if (fieldIndex!=-1):
            if (fieldValidation):
                value = passport[fieldIndex:].split("\n")[0].split(" ")[0].split(":")[1].strip()
                if (not isValidField(field, value)):
                    return False
        else:
            return False
    return hasFields

def isValidField(field, value):
    reg = fieldValidators[field]
    return re.match(reg, value) != None