cmake_minimum_required(VERSION 3.3)
project(05_CreateNewInteger)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++11")
set(CMAKE_C_FLAGS "${CMAKE_C_FLAGS} -Wall -std=c11")

set(SOURCE_FILES 05-create-new-int.c)
add_executable(05_CreateNewInteger ${SOURCE_FILES})