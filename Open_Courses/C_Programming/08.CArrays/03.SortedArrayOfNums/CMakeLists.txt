cmake_minimum_required(VERSION 3.3)
project(03_SortedArrayOfNums)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")
set(SOURCE_FILES 03-sort-arr.c)
add_executable(03_SortedArrayOfNums ${SOURCE_FILES})