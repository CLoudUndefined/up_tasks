{
  pkgs ? import <nixpkgs> { },
}:

pkgs.mkShell {
  buildInputs = [
    pkgs.dotnet-sdk_9
    pkgs.fontconfig
    pkgs.xorg.libX11
    pkgs.xorg.libXrender
    pkgs.xorg.libXext
    pkgs.xorg.libICE
    pkgs.xorg.libSM
  ];

  LD_LIBRARY_PATH = "${pkgs.fontconfig.lib}/lib:${pkgs.xorg.libX11}/lib:${pkgs.xorg.libXrender}/lib:${pkgs.xorg.libXext}/lib:${pkgs.xorg.libICE}/lib:${pkgs.xorg.libSM}/lib";
}
