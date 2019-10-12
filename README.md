# Heap Implementation - C#

This repository contains the implementation of Heap Data structure in C#.

It currently has six classes, namely:

1. MinHeap - contains MinHeap implementation. Supported by an underlying array holding whole data.
2. MaxHeap - contains MaxHeap implementation. Supported by an underlying array holding whole data.
3. TopNMinHeap - contains implementation for fetching Top N items using min heap. Supporting array is limited to only N items. Better time & space complexity.
4. BottomNMaxHeap - contains implementation for fetching Bottom N items using max heap. Supporting array is limited to only N items. Better time & space complexity.
5. TopNEntityMinHeap - implementation for fetching Top N Entities using min heap based on a property of the entity. 
6. BottomNEntityMaxHeap - implementation for fetching Bottom N Entities using max heap based on a property of the entity.

Program.cs file contains some sample tests and metrics (time measurements) using above four implementations.

PriceData.cs - is a sample price data (finance) entity which is used for testing TopNEntityMinHeap / BottomNEntityMaxHeap implementations.
