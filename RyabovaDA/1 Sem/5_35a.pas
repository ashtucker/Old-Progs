program z535a;
begin
readln(a,b);
for i:=1 to 20 do
    for j:=1 to 40 do
                   begin
                   x:=sin(i*x - pi/4) + cos(j*x + i*x);
                   if ((x > a) and (x < b)) then
                   sum:=sum+x;
                   end;
writeln(sum)
end.