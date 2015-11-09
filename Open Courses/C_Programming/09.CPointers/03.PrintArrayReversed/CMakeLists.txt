cmake_minimum_required(VERSION 3.3)
project(03_PrintArrayReversed)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")

set(SOURCE_FILES main.cpp)
add_executable(03_PrintArrayReversed ${SOURCE_FILES})