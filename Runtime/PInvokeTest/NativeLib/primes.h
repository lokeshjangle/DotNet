#pragma once
#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif
#ifdef __cplusplus
extern "C" {
#endif

typedef long long int pnum_t;

EXPORT int primes_count(pnum_t first, pnum_t last);

typedef struct{
	pnum_t start;
	int count;
}prange_t;

EXPORT pnum_t primes_select(const prange_t* range, pnum_t* selected, int (*selector)(pnum_t));

#ifdef __cplusplus
}
#endif

