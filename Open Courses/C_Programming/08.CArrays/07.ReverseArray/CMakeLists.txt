cmake_minimum_required(VERSION 3.3)
project(07_ReverseArray)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")
set(SOURCE_FILES 07-reverse-array.c)
add_executable(07_ReverseArray ${SOURCE_FILES})