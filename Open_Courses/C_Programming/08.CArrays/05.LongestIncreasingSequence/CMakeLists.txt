cmake_minimum_required(VERSION 3.3)
project(05_LongestIncreasingSequence)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 05-longest-increasing-seq.c)
add_executable(05_LongestIncreasingSequence ${SOURCE_FILES})