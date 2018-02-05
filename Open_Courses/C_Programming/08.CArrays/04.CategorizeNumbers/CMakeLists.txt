cmake_minimum_required(VERSION 3.3)
project(04_CategorizeNumbers)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")
set(SOURCE_FILES 04-categorize-numbers.c)
add_executable(04_CategorizeNumbers ${SOURCE_FILES})