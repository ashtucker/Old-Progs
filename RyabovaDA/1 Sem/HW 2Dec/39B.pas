program 39B;
var a,b,c,p1,p2,p3,y: real;
begin
readln(a,b,c);
p1:=1/exp(4/5*ln(2*sqrt(3)));
p2:=6*exp(1/5*ln(exp(abs(c)*ln(abs(a-abs(b))))));
p3:=ln(p2)/ln(2);
y:=p1*p3;
writeln('y=',y)
end.