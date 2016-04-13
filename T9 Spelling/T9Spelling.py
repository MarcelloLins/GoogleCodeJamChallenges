import string

# Gets the T9 Value of a given Character (E.G:  )
def get_t9_value(t9, value):
    for item in t9:
        if value in item:
            # Multiplying the t9 value by it's index (String multiplication)
            return item[-1] * int(item.index(value) + 1)

def write_case(t9, case, f_writer):
    row_format = 'Case #%d: %s'
    f_writer.write((row_format % (case, t9)) + '\n')

# File Handling
with open('Inputs/C-small-practice.in', 'r') as f_reader:
    with open('Outputs/C-small-practice.out' ,'w') as f_writer:

        # Building T9 "map" manually
        t9 = [' 0','abc2', 'def3', 'ghi4', 'jkl5' , 'mno6', 'pqrs7', 'tuv8', 'wxyz9']

        # Number of Test Cases
        test_cases = int(f_reader.readline())
        test_case  = 1

        # Reading file Lines
        for word in f_reader:
            t9_code = ''

            # Iterating over characters of each word
            for character in word.strip('\n'):
                tmp_t9_code = get_t9_value(t9, character)
                
                # checking for the need to apply a space
                if (len(t9_code) > 1) and (tmp_t9_code[0] == t9_code[-1]): # <-- Problem ( array out of index )
                    t9_code += ' '

                t9_code += tmp_t9_code

            write_case(t9_code,test_case, f_writer)
            test_case += 1

print 'End of Challenge'