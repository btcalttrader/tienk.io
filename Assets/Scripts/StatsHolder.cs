﻿//
//  Copyright (c) 2017  FederationOfCoders.org
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using UnityEngine;

namespace Deepio {
    public class StatsHolder : MonoBehaviour {
        public Stat healthRegen;
        public Stat maxHealth;
        public Stat bodyDamage;
        public Stat bulletPenetration;
        public Stat bulletSpeed;
        public Stat bulletDamage;
        public Stat reload;
        public Stat movementSpeed;

        public void OnRespawn() {
            healthRegen.OnRespawn();
            maxHealth.OnRespawn();
            bodyDamage.OnRespawn();
            bulletSpeed.OnRespawn();
            bulletPenetration.OnRespawn();
            bulletDamage.OnRespawn();
            reload.OnRespawn();
            movementSpeed.OnRespawn();
        }
    }
}
