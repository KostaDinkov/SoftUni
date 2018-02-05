cmake_minimum_required(VERSION 3.3)
project(02_ArrayPrint)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 02-array-print.c)
add_executable(02_ArrayPrint ${SOURCE_FILES})