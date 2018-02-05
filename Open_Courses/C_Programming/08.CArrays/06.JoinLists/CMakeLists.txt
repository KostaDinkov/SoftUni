cmake_minimum_required(VERSION 3.3)
project(06_JoinLists)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 06-join-lists.c)
add_executable(06_JoinLists ${SOURCE_FILES})