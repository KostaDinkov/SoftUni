cmake_minimum_required(VERSION 3.3)
project(02_LiearSearch)

set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 02-linear-search.c)
add_executable(02_LiearSearch ${SOURCE_FILES})