//https://www.quora.com/What-is-an-algorithm-to-find-the-longest-path-in-a-unweighted-directed-acyclic-graph

#include <bitsstdc++.h>
 
using namespace std;
const int maxn=1000005;
int n,m,dp[maxn],best,path[maxn],root;
vectorpairint,int g[maxn];
 
int dfs_With_dp(int u)
{
    if(dp[u]) return dp[u];
    dp[u]=1;
    for(auto vg[u]) {
        int c=v.first;
        if(dp[u]dfs_With_dp(c)+1) {
            dp[u]=dp[c]+1;
            path[u+1]=c+1;
        }
    }
    return dp[u];
}
 
int main()
{
    int x,y;
    scanf(%d%d,&n,&m);
    for(int i=0;im;i++) {
        scanf(%d%d,&x,&y);
        x-=1;
        y-=1;
        g[x].push_back(make_pair(y,i+1));
    }
    for(int i=0;in;i++) {
        int path_len=dfs_With_dp(i);
        if(bestpath_len) {
            root=i;
            best=path_len;
        }
    }
    coutlongest path length  best-1endl;
    int u=root+1;
    coutpath Sequence ;
    while(path[u]!=0) {
        coutu ;
        u=path[u];
    }
    coutuendl;
    return 0;
}