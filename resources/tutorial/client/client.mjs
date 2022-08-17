import * as alt from 'alt';
import * as native from 'natives';

const localPlayer = alt.Player.local;

alt.onServer('Event:Objektas', (objPav) =>{
    alt.log("Veikia " + objPav)

    native.createObject(alt.hash(objPav), localPlayer.pos.x, localPlayer.pos.y, localPlayer.pos.z-1, false, false, false)
})