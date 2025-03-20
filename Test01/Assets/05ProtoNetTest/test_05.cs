using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using ProtoBuf;
using UnityEngine;

namespace Example_05
{


    public class test_05 : MonoBehaviour
    {
        
        private string path ;
        private BinaryFileLoader loader;
        private void Awake()
        {
            path =Application.persistentDataPath + "/person.dat";
            loader = new BinaryFileLoader();
            var person = GeneratePerson();
            SavePerson(person);
            Debug.Log("数据存储");
            loadPersonDelay();
        }


        private async void loadPersonDelay()
        {
            await Task.Delay(3000);
            Debug.Log("数据读取");
            var person = await loader.LoadData<Person>();
            Debug.Log("数据输出");
            Debug.Log(person);
        }
        
        
        


        private Person GeneratePerson()
        {
            // 生成一个Person对象
            Person person = new Person();
            person.Id = 1;
            person.Name = "test_05";
            person.Address = new Address(){City = "昌平", Province = "北京"}; ;
            return person;
        }
        
        
        // 序列化一个Person对象，并存储到本地
        private void SavePerson(Person person)
        {
            Debug.Log("path: " + path);
            // 序列化Person对象
            using (var file = File.Create(path))
            {
                Serializer.Serialize(file,person);
            }
        }
    }
}
