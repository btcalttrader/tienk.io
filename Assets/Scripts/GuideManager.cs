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

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Tienkio {
    public class GuideManager : Singleton<GuideManager> {
        public GameObject guideBox;
        public Text guideText;

        public bool displayGameGuide;

        [TextArea(3, 10)]
        public string[] gameGuide;

        bool isGuideLoaded;
        string[] currentGuide;
        int currentGuidePart;

        void Start() {
            if (displayGameGuide) {
                LoadGuide(gameGuide);
                displayGameGuide = false;
            }
        }

        public void LoadGuide(string[] guide) {
            currentGuide = guide;
            currentGuidePart = 0;

            guideBox.SetActive(true);
            DisplayNextGuidePart();

            isGuideLoaded = true;
        }

        void Update() {
            if (isGuideLoaded) {
                Time.timeScale = 0;

                if (Input.GetButtonDown("Continue Guide"))
                    DisplayNextGuidePart();
                if (Input.GetButtonDown("Skip Guide"))
                    EndGuide();
            }
        }

        void EndGuide() {
            currentGuide = new string[] { };
            currentGuidePart = 0;

            guideBox.SetActive(false);
            StopAllCoroutines();
            guideText.text = "";

            Time.timeScale = 1;
            isGuideLoaded = false;
        }

        void DisplayNextGuidePart() {
            if (currentGuidePart >= currentGuide.Length) {
                EndGuide();
            } else {
                string guidePart = currentGuide[currentGuidePart];
                currentGuidePart++;

                StopAllCoroutines();
                StartCoroutine(TypeDialogue(guidePart));
            }
        }

        IEnumerator TypeDialogue(string dialogue) {
            guideText.text = "";
            foreach (char letter in dialogue) {
                guideText.text += letter;
                yield return null;
            }
        }
    }
}
