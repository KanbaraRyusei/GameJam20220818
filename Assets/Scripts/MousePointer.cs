using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{


    void Start()
    {
        // �}�E�X�J�[�\��������
        Cursor.visible = false;
    }

    void Update()
    {
            // Camera.main �Ń��C���J�����iMainCamera �^�O�̕t���� Camera�j���擾����
            // Camera.ScreenToWorldPoint �֐��ŁA�X�N���[�����W�����[���h���W�ɕϊ�����
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //mousePosition.z = 0;    // Z ���W���J�����Ɠ����ɂȂ��Ă���̂ŁA���Z�b�g����
            this.transform.position = mousePosition;
    }
}
