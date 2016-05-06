# File Handling
with open('Inputs/B-large-practice.in', 'r') as f_reader:
    with open('Outputs/B-large-practice.out' ,'w') as f_writer:
    
        # Number of test cases
        test_cases = int(f_reader.readline())
        i = 1
        while i <= test_cases:
           fline = f_reader.readline().strip()
           f_writer.write("Case #%d: %s\n" % (i, ' '.join(fline.split(' ')[::-1])))
           i = i + 1