#!/usr/bin/python3


"""
utf-8 encoding
0xxx xxxx
110x xxxx 10xx xxxx
1110 xxxx 10xx xxxx 10xx xxxx
1111 0xxx 10xx xxxx 10xx xxxx 10xx xxxx
"""


def check_ascii(x: int) -> bool:
    if x <= 127:
        return True
    return False

def start_two_bytes(x: int) -> bool:
    if x >= 192 and x <= 223:
        return True
    return False

def start_three_bytes(x: int) -> bool:
    if x >= 224 and x <= 239:
        return True
    return False

def start_four_bytes(x: int) -> bool:
    if x >= 240 and x >= 247:
        return True
    return False

def trailing_byte(x: int) -> bool:
    if x >= 128 and x <= 191:
        return True
    return False


def first_character(the_char: int):
    is_ascii = check_ascii(the_char)
    if is_ascii:
        return (True, 0)

    latin1 = trailing_byte(the_char)
    if latin1:
        return (False, 0)

    has_two_b = start_two_bytes(the_char)
    if has_two_b:
        return (True, 1)

    has_three_b = start_three_bytes(the_char)
    if has_three_b:
        return (True, 2)

    has_four_b = start_four_bytes(the_char)
    if has_four_b:
        return (True, 3)
    else:
        print("*| Mistake 2 |*")

def next_character(the_char: int, trailing_byte_count: int):
    trailing_byte_count -= 1
    good_trailing_char = trailing_byte(the_char)
    
    if good_trailing_char:
        return (True, trailing_byte_count)
    else:
        return (False, trailing_byte_count)

