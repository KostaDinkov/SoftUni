cmake_minimum_required(VERSION 3.3)
project(01_SwapNumbers)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 01-swap-numbers.c)
add_executable(01_SwapNumbers ${SOURCE_FILES})