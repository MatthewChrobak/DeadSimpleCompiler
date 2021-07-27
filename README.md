# DeadSimpleCompiler
Hacked this out in a few hours. This is meant to show the workings of a very simple compiler. Any faults in the lexical, syntax, semantics, or code generation, may lead to a non-graceful termination of the compiler.
The project is meant to showcase the success scenario.

A sample source can be found as "Source.dss"

```c
foo () {
  Print(Testing);
}
main () {
  Print(Hello);
  Print(5);
  foo();
}
```

Should compile down into "source.c".

```c
#include <stdio.h>
void PrintStr(const char* value) { printf("%s", value); }
void PrintInt(int value) { printf("%d", value); }
void foo() {
	PrintStr("Testing");
}
void main() {
	PrintStr("Hello");
	PrintInt(5);
	foo();
}

```
