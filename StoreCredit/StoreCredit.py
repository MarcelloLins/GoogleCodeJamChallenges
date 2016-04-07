# File Handling
with open('Inputs/A-large-practice.in', 'r') as f_reader:
    with open('Outputs/A-large-practice.out' ,'w') as f_writer:
                
        # Number of Test Cases
        test_cases = int(f_reader.readline())
    
        test_case = 1
        while test_case <= test_cases:
            
            # Reading next 3 Lines
            store_credit = int(f_reader.readline())
            products_count = int(f_reader.readline())
            product_prices = f_reader.readline()
            
            # Converting array of strings to array of ints
            product_prices = map(lambda x: int(x), product_prices.split(' '))
            
            # Array Indexes used to navigate through
            anchor_idx, current_idx, found_sum = 0, 0, False
            
            print 'Test Case #%d' % test_case
            
            # Iterating over list elements
            while anchor_idx < products_count and not found_sum:
                
                # Avoids having to iterate through the array
                current_idx = anchor_idx + 1
                while current_idx < products_count:
                    
                    # Summing
                    anchor_price = product_prices[anchor_idx]
                    current_price = product_prices[current_idx] 
                    products_sum = anchor_price + current_price
                
                    # Have we found the sum ?
                    if products_sum == store_credit:
                        print '%d + %d = %d' % (anchor_price, current_price, products_sum)
                        
                        # Writing result to output file
                        output_line = 'Case #%d: %d %d\n'
                        if anchor_idx < current_idx:
                            f_writer.write((output_line % (test_case, anchor_idx + 1, current_idx + 1)));
                        else:
                            f_writer.write((output_line % (test_case, current_idx + 1, anchor_idx + 1)));
                        found_sum = True
                        break
                
                    current_idx = current_idx + 1
            
                anchor_idx = anchor_idx + 1
            
            test_case = test_case + 1

print 'End of Challenge'