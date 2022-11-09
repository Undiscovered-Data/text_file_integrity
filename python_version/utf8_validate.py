#!/usr/bin/python3

from utf8_validate_lib import check_ascii, first_character, next_character

ofile = open('test.txt', 'rb')
#ofile = open('test2.txt', 'rb')
rfile = ofile.read()

trailing_byte_count = 0
chr_count = 0
for char in rfile:
    chr_count += 1
    if trailing_byte_count == 0:
        good_ascii = check_ascii(char)
        if good_ascii:
            continue

        good_char, more_chars = first_character(char)
        if good_char and more_chars >= 1 and more_chars <= 3:
            trailing_byte_count = more_chars
            continue

        elif good_char == False:
            print(char, "*", chr_count)
        
        else:
            print("*| Mistake 1 |*")

    else:
        good_char, more_chars = next_character(char, trailing_byte_count)
        trailing_byte_count = more_chars
        if good_char:
            continue
        else:
            print(chr_count)
"""
for char in rfile:
    print(char)
"""
ofile.close()


