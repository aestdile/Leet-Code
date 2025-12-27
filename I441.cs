public class Solution {
    public int MostBooked(int n, int[][] meetings) {
            var roomUseCnt = new int[n];
            var freeRoomPQ = new PriorityQueue<int, int>();
            var usingRoomPQ = new PriorityQueue<(long EndTime, int RoomID), (long EndTime, int RoomID)>();

            for (var i = 0; i < n; i++)
            {
                freeRoomPQ.Enqueue(i, i);
            }

            Array.Sort(meetings, (a, b) => a[0].CompareTo(b[0]));

            foreach (var meeting in meetings)
            {
                while (usingRoomPQ.Count > 0 && usingRoomPQ.Peek().EndTime <= meeting[0])
                {
                    var finishedMeeting = usingRoomPQ.Dequeue();
                    freeRoomPQ.Enqueue(finishedMeeting.RoomID, finishedMeeting.RoomID);
                }

                var roomID = -1;
                var waitTime = 0L;

                if (freeRoomPQ.Count > 0)
                {
                    roomID = freeRoomPQ.Dequeue();
                }
                else
                {
                    var nextMeeting = usingRoomPQ.Dequeue();
                    roomID = nextMeeting.RoomID;
                    waitTime = nextMeeting.EndTime - meeting[0];
                }

                roomUseCnt[roomID]++;
                var endTime = meeting[1] + waitTime;

                usingRoomPQ.Enqueue((endTime, roomID), (endTime, roomID));
            }

            var maxIdx = -1;
            var maxCount = -1;

            for (var i = 0; i < n; i++)
            {
                if (roomUseCnt[i] > maxCount)
                {
                    maxCount = roomUseCnt[i];
                    maxIdx = i;
                }
            }


            return maxIdx;
    }
}
